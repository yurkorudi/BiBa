from app_conectivity import Connect
from resemble import Resemble
from build_in_func import Welcome_func
from openai import OpenAI
from pathlib import Path
from build_in_func import Main_functions

app = Connect()
welcome = Welcome_func()

client = OpenAI(api_key=open("./keys/biba_key.txt", 'r').read())

bib = Main_functions(client)
bib.text_to_speech('Привіт, моя дорога Оленко. Як ти там? Як твоє життя? Я скучив. Чекаю поки ми підеом звідси. Люблю тебе.')

