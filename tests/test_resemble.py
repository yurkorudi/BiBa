from resemble import Resemble
Resemble.api_key('YOUR_API_TOKEN')
  
page = 1
page_size = 10
  
response = Resemble.v2.voices.all(page, page_size)
voices = response["items"]