#!/bin/bash

FILES="./*"

# Go to local current directory
cd $LOCAL_FOLDER
ftp -inv <<EOF
open $FTP_HOST
user $FTP_USER $FTP_PASSWORD
cd /test_folder
mput $FILES
bye
