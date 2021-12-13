Following sample .NET 6 projects demonstrate how to integrate with our ANT Non Profit Cloud

# Architecture

![architecture](/docs/images/arch.png)

# WebHook loop
When sending data to the ANT Non Profit Cloud HUB API, you will get back the WebHooks sent by our platform. To avoid loop within WebHooks, the sample application uses a dockerized [redis](https://redis.io/) cache. See [here](https://jeremylindsayni.wordpress.com/2016/11/24/connect-to-a-redis-container-hosted-in-docker-from-a-net-core-application/) for detailed information on how run redis inside docker.

In order to be able to detect a WebHook sent because of own API call, you have to set a CorrelationId (x-correlation-id header) for each API-Call. Our platform will add this CorrelationId to the WebHook triggered by the API-Call.
![correlationid](/docs/images/correlationid.png)

# Setup your tenant

1. Navigate to our [ANT Non Profit Cloud UI](https://app.test.sextant.cloud)
2. Click "Login"
3. Click "Sign Up now"
4. Enter your email address
   4.1 You will get an email with the Verification Code
   4.2 Enter the received Verification Code
5. Enter a Password and confirm it
6. Enter a Display Name
7. Click create

You will be redirected to the start page.

# ANT Non Profit Cloud HUB-API

Our API provide a [Swagger-UI](https://hub.test.sextant.cloud/index.html) where all endpoint and schemas are documented. It's also possible to play around before running the client app provided in this sample repository.

# Prerequisites

- run redis in docker **docker run -d --name myRedis -p 6379:6379 redis**
- download [ngrok](https://ngrok.com/download)
- expose a web server using ngrok on port of webhookreceiver: **./ngrok http 5000**

# webhookreceiver

This [ASP.NET Core Minimal API](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0) receives WebHooks from the ANT Non Profit Cloud HUB.
To keep it as simple as possible, the application validates only the received hash and outputs the WebHook content to the console.

_note: API must be public in order to get called from our ANT Non Profit Cloud HUB. To achieve this, you could use [ngrok](https://ngrok.com/) which is setup quickly._

## Setup

After downloading ngrok and adding your specific port, you must register the WebHook endpoint in the ANT Non Profit Cloud HUB:

1. Navigate to our [ANT Non Profit Cloud UI](https://app.test.sextant.cloud)
2. Click "Configuration" in the left navigation
3. Click "WebHooks"
4. Enter the URL provided by ngrok
5. Click Save
6. You will see a Secret. Please Copy it because you need it after starting webhookreceiver

# clientapp

This .NET 6 ConsoleApp serve as the smallest possible UI to create CRM object in HUB and outputs the result of API-Calls. It uses [refit](https://github.com/reactiveui/refit) to create an API-Client.

## Setup

After starting the application you will be asked to provide a TenantId and the Url to out ANT Non Profit Cloud HUB-API

# frameworks and tools

- ASP.NET Core Minimal API
- ngrok
- refit
- redis
