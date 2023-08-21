#!/bin/bash

FILES="./*"

# Go to local current directory
cd $LOCAL_FOLDER
ftp -inv <<EOF
open $FTP_HOST
user $FTP_USERNAME $FTP_PASSWORD
cd /test_folder
prompt
mput *
mdel app_offline.htm
bye
