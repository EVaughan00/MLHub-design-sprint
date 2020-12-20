#!/bin/bash

docker build . -f Services/APIGateway/Dockerfile -t evaughan00/mlhub-api-gateway:$1
docker build . -f Services/AuthResource/AuthResource.API/Dockerfile -t evaughan00/mlhub-auth-resource:$1
docker build . -f Services/Models/Models.API/Dockerfile -t evaughan00/mlhub-api-models:$1

docker push evaughan00/mlhub-api-gateway:$1
docker push evaughan00/mlhub-api-models:$1
docker push evaughan00/mlhub-auth-resource:$1
