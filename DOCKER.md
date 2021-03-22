# Docker Helper

## Dockerfile
* __build__: docker build -t \<tagname> .
* __run__: docker run -p \<localport>:\<remoteport> \<tagname>
* __list docker images__: docker images ls
* __push to dockerhub__: docker push \<tagname>

## Docker Compose
* __compose build__: docker-compose build
* __compose run__: docker-compose up

## Car Finder Commands
* __build__: docker build -t geekymon2/carfinder .
* __run__: docker run --rm -p 5000:5000/tcp geekymon2/carfinder
* __compose build__: docker-compose build
* __compose run__: docker-compose up