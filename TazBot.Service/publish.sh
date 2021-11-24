#!/bin/bash

echo "Publishing"
dotnet publish -c Release  -r ubuntu-x64 --self-contained

echo "Adding run permission to executable"
chmod +x /home/eli/source/TazBot/TazBot.Service/bin/Release/net6.0/ubuntu-x64/publish/TazBot.Service

echo "Copying service information"
sudo cp TazBot.Service.service /etc/systemd/system/TazBot.Service.service

echo "Starting Serice"
sudo systemctl daemon-reload
sudo systemctl start TazBot.Service.service

echo "Waiting for garbage to run"
sleep 5

echo "Viewing Service"
sudo journalctl -u TazBot.Service.service -n 50 --no-pager