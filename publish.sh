#! /bin/bash

cd ./ClientApp && npm run pub && cd ..
dotnet publish -o ./bin/Release
docker build -t avionicscloud/ui .