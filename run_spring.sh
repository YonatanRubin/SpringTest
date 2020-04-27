SCRIPTPATH="$( cd "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P )"/config
echo $SCRIPTPATH

docker run -d -p 8888:8888 -v $SCRIPTPATH:/config -e SPRING_PROFILES_ACTIVE=native --name spring hyness/spring-cloud-config-server
