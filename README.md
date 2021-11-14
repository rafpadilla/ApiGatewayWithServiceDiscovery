# Api Gateway with Service Discovery (Ocelot with Consul)

This sample uses Ocelot as an apigateway and load balancer connected with Consul (Service Discovery), balancing requests to a sample web application, which have 3 replica.

The web application registers itself in Consul using its hostname (also could be configured using the container IP). Ocelot reads the available services from Consul to expose the working containers and makes balancing request between these 3 replica.

## Running the sample

Run the `docker-compose.yml` file in the repository, this will start 5 containers: consul, apigateway and 3 replicas of the sample web application.
```bash
docker-compose up -d
```

Once you can open your browser pointing to the apigateway:
```
http://localhost:8080
```

Also for check services in Consul:
```
http://localhost:8500
```

Then you can see something similar to this

Consul with all services registered:
![Consul with all services registered](../media/consul_services.png)


Web application replicas with hostname highlighted:
![Web application replicas with hostname highlighted](../media/consul_webapp_replicas.png)

Diferent responses from services through the api gateway:

![Response from service 1](../media/service1_response.png)

![Response from service 2](../media/service2_response.png)

![Response from service 3](../media/service3_response.png)
