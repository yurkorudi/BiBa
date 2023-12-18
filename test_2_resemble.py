from resemble import Resemble
Resemble.api_key('YOUR_API_TOKEN')
  
name = 'My project'
description = 'My description'
is_public = False
is_archived = False
is_collaborative = False
  
response = Resemble.v2.projects.create(name, description, is_public, is_collaborative, is_archived)
#project = response['item']