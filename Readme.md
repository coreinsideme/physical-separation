# Notes for Physical Layer Separation Project

## TODO:

- Implement data retrieving;
- Implement parameters passing to DB queries;
- Add test project;
- Add Identity Management system usage;

## RabbitMQ

For RabbitMQ I have pulled the version 3.10 of rabbitmq image. To run please make next steps:

docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.10-management

##Sonarqube

For Sonarqube I used the latest version of sonarqube image from official website. To run please install sonarscanner globally:

dotnet tool install --global dotnet-sonarscanner

then make the next steps:

dotnet sonarscanner begin /k:"project_name" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="%project_key%"

dotnet build

dotnet sonarscanner end /d:sonar.login="%project_key%"

