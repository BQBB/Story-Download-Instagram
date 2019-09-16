import requests
import json
import re
import urllib.request
import argparse
ids=lambda user: requests.get('https://www.instagram.com/'+user).text
def download(ids,userat):
    ids=re.search('"profilePage_(.*?)",',ids).group(1)    
    req=requests.get('http://mrvirus.cf/StoryDownload.php?id='+ids).text
    x=re.findall('{URL:(.*?)}',req)
    ib=0
    for i in x:
        if 'mp4' in i:
            urllib.request.urlretrieve(i,userat+str(ib)+'.mp4')
            ib+=1

        else:
            urllib.request.urlretrieve(i,userat+str(ib)+'.jpg')
            ib+=1
    return True
def parse():
    arg=argparse.ArgumentParser()
    arg.add_argument('-u','--user',dest='user',help='-u , --user use to pass user instagram')    
    return arg.parse_args().user
user=parse()
if(user):
    ids=ids(user)
    download(ids,user)
    input('Finished...')
else:
    user=str(input('username : '))
    ids=ids(user)
    download(ids,user)
    input('Finished...')
