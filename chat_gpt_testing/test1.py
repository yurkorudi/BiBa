from openai import OpenAI
client = OpenAI(api_key="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")

response = client.chat.completions.create(
  model="gpt-3.5-turbo",
  messages=[
    {"role": "system", "content": "You are a helpful assistant."}
  ]
)

print(response[1]["content"])