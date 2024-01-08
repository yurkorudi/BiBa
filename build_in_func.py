
class Welcome_func:
    def __init__(self):
        print('hello world')




class Main_functions: 
    def __init__(self, client):
        self.client = client
        self.speech_output_path = './speech_outputs'


    def speech_to_text(self, file):
        self.file = open(file, 'rb')
        self.transcript = self.client.audio.translations.create(
            model="whisper-1", 
            file= self.file,
            response_format="text"
        )
        return self.transcript
    

    def text_to_speech(self, text):
        self.speech = self.client.audio.speech.create(
            model='tts-1',
            voice='fable',
            input=text
        )
        self.speech.stream_to_file(self.speech_output_path + '/spech.mp3')







    