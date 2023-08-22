#!/bin/bash
ftp -inv <<EOF
open $FTP_HOST
user $FTP_USERNAME $FTP_PASSWORD
cd $REMOTE_FOLDER
prompt
mput *.htm
bye
