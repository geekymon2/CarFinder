# Docker Helper

## Dockerfile
* __build__: docker build -t \<tagname> -f <dockerfile> .
* __run__: docker run -p \<localport>:\<remoteport> \<tagname>
* __list docker images__: docker images ls
* __push to dockerhub__: docker push \<tagname>

## Docker Compose
* __compose build__: docker-compose build
* __compose run__: docker-compose up

## Car Finder Commands
* __build api__: docker build -f Dockerfile.api . -t geekymon2/carfinder-api
* __build db__: docker build -f Dockerfile.db . -t geekymon2/carfinder-db
* __push api__: docker push geekymon2/carfinder-api
* __push db__: docker push geekymon2/carfinder-db
* __run__: docker run --rm -p 5000:5000/tcp geekymon2/carfinder-api
* __run__: docker run --rm -p 1433:1433/tcp geekymon2/carfinder-db