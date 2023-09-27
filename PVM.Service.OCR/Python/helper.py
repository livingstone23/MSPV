import configparser
import os
import logging
import pytesseract
from pathlib import Path
from datetime import datetime
import ctypes


# Método para leer la configuración dentro del config
def read_config():
    config = configparser.ConfigParser()
    #config.read(os.path.abspath('config.ini'))
    config.read("C:\Otros\mspv2\PVM.Service.OCR\Python\config.ini")
    return config


# Establece la dirección de ejecución para la librería de Tesseract-OCR
def setup_tesseract_ocr():
    pytesseract.pytesseract.tesseract_cmd = os.path.abspath(r'.\Python\tesseract-ocr\tesseract.exe')
    logging.info('PyTesseract set - ' + str(pytesseract.get_tesseract_version()))


# Inicialización del log para esta ejecución
def setup_logger():
    config = read_config()
    log_file_path = config.get('Logger', 'logfilepath')
    if not os.path.exists(log_file_path):
        os.mkdir(log_file_path)
    log_path = log_file_path + datetime.today().strftime('%Y-%m-%d') + '_' + config.get('Logger', 'logfilename') + '.log'
    if not os.path.exists(log_path):
        Path(log_path).touch(exist_ok=True)

    logging.basicConfig(filename=log_path,
                        encoding='utf-8',
                        level=logging.DEBUG,
                        format='%(asctime)s - %(message)s')
    logging.info('INICIO--Logger set')
    # Para escribir un mensaje de log nuevo usar <<logging.info('Línea del log')>>


# Obtiene el alto y ancho de la pantalla
def screen_dim():
    user32 = ctypes.windll.user32
    user32.SetProcessDPIAware()
    width, height = user32.GetSystemMetrics(0), user32.GetSystemMetrics(1)
    dims = [width, height]
    return dims