from openai import OpenAI
from pathlib import Path
client = OpenAI(api_key="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")

audio_file= open("D:/!_BibA/BiBa/sound_testing/test3.mp3", "rb")
transcript = client.audio.translations.create(
  model="whisper-1", 
  file=audio_file,
  response_format="text"
)
print(transcript)

speech_file_path = Path(__file__).parent / "speech.mp3"
response = client.audio.speech.create(
  model="tts-1",
  voice="fable",
  input=transcript
)
response.stream_to_file(speech_file_path)