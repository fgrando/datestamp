#!/bin/python3

from PyQt5.QtWidgets import QMessageBox, QLabel, QSizePolicy, QWidget, QMainWindow, QApplication, QVBoxLayout, QDateEdit, QLineEdit

from PyQt5.QtGui import QFont
from PyQt5.QtCore import QTimer

import os
import sys
import datetime


class MainWidget(QMainWindow):
    def __init__(self):
        super().__init__()
        title = os.path.basename(sys.argv[0])
        self.setWindowTitle(title)
        self.resize(450, 180)
        self.setAcceptDrops(True)

        self.prefix='<datetime format here>'

        widget = QWidget()
        layout = QVBoxLayout()
        self.display = QLabel(widget)
        self.display.setFont(QFont('Arial', 25))
        self.display.setSizePolicy(QSizePolicy.Expanding,QSizePolicy.Expanding)

        self.labelFormat = QLabel("format:", widget)
        self.format = QLineEdit("%Y.%m.%d-%H.%M.%S_", widget)

        layout.addWidget(self.display)
        layout.addWidget(self.labelFormat)
        layout.addWidget(self.format)
        widget.setLayout(layout)
        self.setCentralWidget(widget)

        # timer to update displayed prefix
        self.timer = QTimer(self)
        self.timer.timeout.connect(self.tictac)
        self.timer.start(1000) # update every second
        self.tictac()


    def dragEnterEvent(self, event):
        if event.mimeData().hasUrls():
            event.accept()
        else:
            event.ignore()


    def dropEvent(self, event):
        files = [u.toLocalFile() for u in event.mimeData().urls()]
        for f in files:
            self.rename(f)


    def tictac(self):
        fmt = self.format.text()
        self.prefix = datetime.datetime.now().strftime(fmt)
        self.display.setText(self.prefix)


    def rename(self, file):
        name = f'{self.prefix}{os.path.basename(file)}'
        newname = os.path.join(os.path.dirname(file), name)
        qm = QMessageBox()
        ret = qm.question(self,'', f"Rename to {newname}", qm.Yes | qm.No)
        if ret == qm.Yes:
            print(newname)
            os.rename(file, newname)


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ui = MainWidget()
    ui.show()
    sys.exit(app.exec_())
