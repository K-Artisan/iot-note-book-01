# 目录

[TOC]



# 前言

代码：https://github.com/sufish/mqtt-nodejs-sample



# 参考资料

官网：http://mqtt.org/

类库：https://github.com/mqtt/mqtt.org/wiki/libraries

公共的Broker：mqtt.eclipse.org。



https://github.com/mcxiaoke/mqtt

https://blog.csdn.net/panwen1111/article/details/79245161

https://github.com/chkr1011/MQTTnet



MQTTnet:

https://github.com/chkr1011/MQTTnet/wiki/Client

https://github.com/rafiulgits/mqtt-client-dotnet-core



https://www.cnblogs.com/lypstudy/p/10515791.html

https://blog.csdn.net/weixin_42930928/article/details/82383297

MQTTnet:https://gitee.com/sesametech-group/MqttNetSln

Aspnet+ MQTTnet: 

https://gitee.com/sesametechgroup/AspNetCoreMqtt

https://github.com/rafiulgits/mqtt-client-dotnet-core



# 1 什么是物联网


物联网（Internet of Things）最早的定义是：把所有物品通过射频识别等信息传感设备与互联网连接起来，实现智能化识别和管理。当然，物联网发展到今天，它的定义和范围已经有了扩展与变化，下面是现代物联网具有的两个特点。



### 物联网也是互联网

物联网，即物的互联网，属于互联网的一部分。物联网将互联网的基础设施作为信息传递的载体，即现代的物联网产品一定是“物”通过某种方式接入了互联网，而“物”通过互联网上传/下载数据，以及与人进行交互。



### 联网的主体是“物”

物联网应用和传统互联网应用又有一个很大的不同，那就是传统互联网生产和消费数据的主体是人，而现代物联网生产和消费数据的主体是物。



## 1.1 物联网和人工智能

人工智能的概念是在1956年提出的，之前一直不温不火，直到最近几年才得以飞速发展，尤其是以神经网络为代表的深度学习，发展更为迅速。



纵观人工智能的发展路线，我们可以看到，人工智能的发展之所以能够突飞猛进，主要有以下两个原因。

- 硬件的发展使得深度学习神经网络的学习时间迅速缩短。-
- 在大数据的时代，获取大量数据的成本变低。



物联网设备，比如智能家电、可穿戴设备等，每天都在产生海量的数据，这些数据经过处理和清洗后，都可以作为不错的训练数据反哺神经网络。同时，训练出来的神经网络又可以重新应用到物联网设备中，进而形成一个良性循环。这里举个例子，通过交通探头，我们可以采集大量的实时交通图片。经过处理，我们把图片“喂给”神经网络，比如SSD（Single Shot MultiBox Detector）。SSD先学会在图片中标注出人和汽车的位置，然后把模型部署到探头端，探头就可以利用深度学习的结果，实时分析人流和车流情况。



## 1.2 物联网的现状与前景



物联网的应用场景非常广泛，包括：
·智慧城市
·智慧建筑
·车联网
·智慧社区
·智能家居
·智慧医疗
·工业物联网



在不同的场景下，物联网应用的差异非常大，终端和网络架构的异构性强，这意味着在物联网行业存在足够多的细分市场，这就很难出现一家在市场份额上具有统治力的公司，同时由于市场够大，所以能够让足够多的公司存活。这种情况在互联网行业是不常见的，互联网行业的头部效应非常明显，市场绝大部分份额往往被头部的两三家公司占据。



所以说，物联网行业目前仍然是一片蓝海，小规模公司在这个行业中也完全有能力和大规模公司同台竞争。在AI和区块链的热度冷却后，物联网很有可能会成为下一个风口。作为程序员，在风口来临之前，提前进行一些知识储备是非常有必要的。



## 1.3 常见的物理网协议



# 2 常见的物联网协议

本章将简单介绍一些常见的物联网协议，包括物理层协议、数据链路层协议和应用层协议



## 2.1 MQTT协议

MQTT协议（Message Queue Telemetry Transport，消息队列遥测传输协议）是IBM的Andy Stanford-Clark和Arcom的Arlen Nipper于1999年为了一个通过卫星网络连接输油管道的项目开发的。为了满足低电量消耗和低网络带宽的需求，MQTT协议在设计之初就包含了以下几个特点。

- 实现简单；
- 提供数据传输的QoS；
- 轻量、占用带宽低；
- 可传输任意类型的数据；
- 可保持的会话（Session）
- 

简单来说，MQTT协议有以下特性。

- 基于TCP协议的应用层协议；
- 采用C/S架构；
- 使用订阅/发布模式，将消息的发送方和接受方解耦；
- 提供3种消息的QoS（Quality of Service）：至多一次、最少一次、只有一次；
- 收发消息都是异步的，发送方不需要等待接收方应答。
- MQTT协议的架构由Broker和连接到Broker的多个Client组成，如图2-1所示。



<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614235815778.png" alt="1614235815778" style="zoom:80%;" />

## 2.2 MQTT-SN协议

MQTT-SN（MQTT for Sensor Network）协议是MQTT协议的传感器版本。MQTT协议虽然是轻量的应用层协议，但是MQTT协议是运行于TCP协议栈之上的，TCP协议对于某些计算能力和电量非常有限的设备来说，比如传感器，就不太适用了。
MQTT-SN运行在UDP协议上，同时保留了MQTT协议的大部分信令和特性，如订阅和发布等。MQTT-SN协议引入了MQTT-SN网关这一角色，网关负责把MQTT-SN协议转换为MQTT协议，并和远端的MQTT Broker进行通信。MQTT-SN协议支持网关的自动发现。



MQTT-SN协议的通信模型：

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614235960092.png" alt="1614235960092" style="zoom:80%;" />





## 2.3 CoAP协议

CoAP（Constrained Application Protocol）协议是一种运行在资源比较紧张的设备上的协议。和MQTT-SN协议一样，CoAP协议通常也是运行在UDP协议上的。

CoAP协议设计得非常小巧，最小的数据包只有4个字节。CoAP协议采用C/S架构，使用类似于HTTP协议的请求-响应的交互模式。设备可以通过类似于coap://192.168.1.150:5683/2ndfloor/temperature的URL来标识一个实体，并使用类似于HTTP的PUT、GET、POST、DELET请求指令来获取或者修改这个实体的状态。
同时，CoAP提供一种观察模式，观察者可以通过OBSERVE指令向CoAP服务器指明观察的实体对象。当实体对象的状态发生变化时，观察者就可以收到实体对象的最新状态，类似于MQTT协议中的订阅功能。



CoAP协议的通信模型

![1614236222562](images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614236222562.png)



## 2.4 LwM2M协议

LwM2M（Lightweight Machine-To-Machine）协议是由Open Mobile Alliance（OMA）定义的一套适用于物联网的轻量级协议。它使用RESTful接口，提供设备的接入、管理和通信功能，也适用于资源比较紧张的设备。



LwM2M协议的架构

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614236315254.png" alt="1614236315254" style="zoom:80%;" />

LwM2M协议底层使用CoAP协议传输数据和信令。而在LwM2M协议的架构中，CoAP协议可以运行在UDP或者SMS（短信）之上，通过DTLS（数据报传输层安全）来实现数据的安全传输。





## 2.5 HTTP协议

正如我们之前所讲，物联网也是互联网，HTTP这个在互联网中广泛应用的协议，在合适的环境下也可以应用到物联网中。在一些计算和硬件资源比较充沛的设备上，比如运行安卓操作系统的设备，完全可以使用HTTP协议上传和下载数据，就好像在开发移动应用一样。设备也可以使用运行在HTTP协议上的WebSocket主动接收来自服务器的数据。



## 2.6  LoRaWAN协议

LoRaWAN协议是由LoRa联盟提出并推动的一种低功率广域网协议，它和我们之前介绍的几种协议有所不同。MQTT协议、CoAP协议都是运行在应用层，底层使用TCP协议或者UDP协议进行数据传输，整个协议栈运行在IP网络上。而LoRaWAN协议则是物理层/数据链路层协议，它解决的是设备如何接入互联网的问题，并不运行在IP网络上。

说到设备如何接入互联网，我们很自然地想到4G、Wi-Fi，如果设备上有4G/Wi-Fi模块，或者支持以太网的网卡，就可以和其他联网终端，比如手机，以同样的方式接入互联网。
但是在某些情况下，4G或者Wi-Fi网络的覆盖非常困难，比如隧道施工的工程设备往往处于隧道深处几千米处，不可能用Wi-Fi或者4G网络覆盖。而工程设备经常在移动，使用有线网络与现场环境也不匹配。

LoRa（Long Range）是一种无线通信技术，它具有使用距离远、功耗低的特点。在上面的场景下，用户就可以使用LoRaWAN技术进行组网，在工程设备上安装支持LoRA的模块。通过LoRa的中继设备将数据发往位于隧道外部的、有互联网接入的LoRa网关，LoRa网关再将数据封装成可以在IP网络中通过TCP协议或者UDP协议传输的数据协议包（比如MQTT协议），然后发往云端的数据中心。



## 2.7 NB-IoT协议

NB-IoT（Narrow Band Internet of Things）协议和LoRaWAN协议一样，是将设备接入互联网的物理层/数据链路层的协议。
和LoRA不同的是，NB-IoT协议构建和运行在蜂窝网络上，消耗的带宽较低，可以直接部署到现有的GSM网络或者LTE网络。设备安装支持NB-IoT的芯片和相应的物联网卡，然后连接到NB-IoT基站就可以接入互联网。而且NB-IoT协议不像LoRaWAN协议那样需要网关进行协议转换，接入的设备可以直接使用IP网络进行数据传输。
NB-IoT协议相比传统的基站，增益提高了约20dB，可以覆盖到地下车库、管道、地下室等之前信号难以覆盖的地方。





# 3 MQTT协议基础

介绍了几种常用的物联网协议，目前的物联网通信协议并没有统一的标准。在这些协议中，MQTT协议（消息队列遥测传输协议）是目前应用最广泛的协议之一。可以这么说，MQTT协议之于物联网，就像HTTP协议之于互联网。目前，基本上所有开放云平台（比如，阿里云、腾讯云、青云等）都支持MQTT的接入，我们可以来看一下它们提供的物联网套件服务。
这些物联网套件服务对MQTT协议的支持都是第一位的。所以，想入门物联网，学习和了解MQTT协议是非常必要的，它解决了物联网中一个最基础的问题，即设备和设备、设备和云端服务之间的通信。
在接下来的几章里，我们将逐一学习MQTT协议的每一个特性及其最佳实践，并辅以实际的代码来进行讲解。其内容包括：

- MQTT协议数据包、数据收发流程详细解析；
- 如何在Web端和移动端正确地使用MQTT协议；
- 如何搭建自己的MQTT Broker；
- 如何增强MQTT平台的安全性；
- 使用MQTT协议设计和开发IoT产品和平台的最佳实践；
- MQTT 5.0的新特性。



MQTT协议是运行在TCP协议栈上的应用层协议，虽然MQTT协议的名称有Message和Queue两个词，但是它并不是像RabbitMQ那样的消息队列，这是初学者最容易搞混的一个问题。



MQTT协议与传统的消息队列相比，有以下几个区别。

1）传统消息队列在发送消息前必须先创建相应的队列。

​      在MQTT协议中，不需要预先创建要发布的主题（可订阅的Topic）。



2）传统消息队列中，未被消费的消息会被保存在某个队列中，直到有一个消费者将其消费。

​      在MQTT协议中，如果发布一个没有被任何客户端订阅的消息，这个消息将被直接扔掉。



3）传统消息队列中，一个消息只能被一个客户端获取。

​     在MQTT协议中，一个消息可以被多个订阅者获取，MQTT协议也不支持指定消息被单一的客户端获取。



MQTT协议有几个不同的版本，目前支持和使用最广泛的版本是3.1.1。

2017年8月，OASIS MQTT Technical Committee正式发布了用于Public Review的MQTT 5.0草案。

2018年，MQTT 5.0正式发布。



MQTT 5.0在MQTT 3.1.1的基础上做了很多改变，并不向下兼容。本书以MQTT 3.1.1标准为主，同时也会讲到MQTT 5.0的新特性。



## 3.1 MQTT协议的通信模型

就像我们之前提到的，MQTT协议的通信是通过发布/订阅的方式来实现的，消息的发布方和订阅方通过这种方式进行解耦，它们之间没有直接的连接，所以需要一个中间方来对信息进行转发和存储。

**在MQTT协议里，**

**我们称这个中间方为Broker，**

**而连接到Broker的订阅方和发布方我们称之为Client**。



一次典型的MQTT协议消息通信流程如图所示

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614238419958.png" alt="1614238419958" style="zoom:80%;" />



1）发布方和订阅方都建立了到Broker的TCP连接。
2）订阅方告知Broker它要订阅的消息主题（Topic）。
3）发布方将消息发送到Broker，并指定消息的主题（Topic）。
4）Broker接收到消息以后，检查都有哪些订阅方订阅了这个主题（Topic），然后将消息发送到这些订阅方。
5）订阅方从Broker获取该消息。
6）如果某个订阅方此时处于离线状态，Broker可以先为它保存此条消息，当订阅方下次连接到Broker的时候，再将之前的消息发送到订阅方。
在本书的后续部分，我们将发送方称为Publisher，将订阅方称为Subscriber。



## 3.2 MQTT Client

任何终端，无论是嵌入式设备，还是服务器，只要运行了MQTT协议的库或者代码并连接了MQTT Broker，我们都称其为MQTT Client。Publisher和Subscriber都属于Client。一个Client是Pushlisher还是Subscriber，只取决于该Client当前的状态——是在发布消息还是在订阅消息。

当然，**一个Client可以同时是Publisher和Subscriber**



在大多数情况下，我们不需要自己按照MQTT的协议规范来实现一个MQTT Client，因为MQTT Client库在很多语言中都有实现，包括Android、Arduino、Ruby、C、C++、C#、Go、iOS、Java、JavaScript以及.NET等。如果你要查看相应语言的库实现，

可以查看https://github.com/mqtt/mqtt.github.io/wiki/libraries。



## 3.3 MQTT Broker

搭建一个完整的MQTT协议环境，除了需要MQTT Client外，我们还需要一个MQTT Broker。如前文所述，Broker负责接收Publisher的消息，并将消息发送给相应的Subscriber，它是整个MQTT协议订阅/发布的核心。

在实际应用中，一个MQTT Broker还应该提供如下功能：

- 可以对Client的接入进行授权，并对Client进行权限控制；
- 可以横向扩展，比如集群，满足海量的Client接入；
- 有较好的扩展性，可以比较方便地接入现有业务系统；
- 易于监控，满足高可用性。



下面列举了几个比较常用的MQTT Broker。

（1）Mosquitto

（2）EMQ X

（3）HiveMQ

（4）VerneMQ



除了上面提到的几个常用的MQTT Broker，你还可以在https://github.com/mqtt/mqtt.github.io/wiki/servers找到更多的MQTT Broker



除了自建Broker，我们还可以使用前面提到的阿里云、腾讯云、青云之类的云服务商提供的物联网云平台的MQTT协议服务。



如果只是抱着学习或者测试的目的，我们还可以使用一些公共的MQTT Broker，这里我们先使用一个公共的MQTT Broker（mqtt.eclipse.org）讲解和学习MQTT协议，在后面的章节里，再学习如何搭建一个MQTT Broker。



## 3.4 MQTT协议数据包格式

MQTT协议使用的是二进制数据包。MQTT协议的数据包非常简单，

一个MQTT协议数据包由**固定头（Fix Header）、可变头（Variable Header）、消息体（Payload）**

这3个部分依次组成。



- 固定头：存在于所有的MQTT协议数据包中，用于表示数据包类型及对应标识，表明数据包大小。

- 可变头：存在于部分类型的MQTT协议数据包中，具体内容由相应类型的数据包决定。

- 消息体：存在于部分MQTT协议数据包中，存储消息的具体数据。

  

这里我们首先看一下固定头，可变头和消息体将在讲解各种具体类型的MQTT协议数据包的时候详细讨论。



### 固定头格式

MQTT协议数据包的固定头的格式

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614241807119.png" alt="1614241807119" style="zoom:80%;" />



#### 数据包类型

MQTT协议数据包的固定头的第一个字节的高4位用于指定该数据包的类型。

MQTT协议的数据包类型如下所示

（2^4=16，一共有16个值）

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614241983173.png" alt="1614241983173" style="zoom:80%;" />![1614242001006](images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614242001006.png)



#### 数据包标识位

MQTT协议数据包的固定头的低4位用于指定数据包的标识位（Flag）。

在不同类型的数据包中，标识位的定义是不一样的，每种数据包对应的标识位如下表所示

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614242449918.png" alt="1614242449918" style="zoom:80%;" />



#### 数据包剩余长度

**从固定位的第二个字节开始**，是用于标识当前数据包剩余长度的字段，剩余长度等于可变头长度加上消息体长度。

**这个字段最少一个字节，最多4个字节**。



其中，每一个字节的最高位叫作延续位（Continuation Bit），用于标识在这个字节之后是否还有一个用于表示剩余长度的字节。剩下的低7位用于标识值，范围为0～127（2^7=1278）。

例如，剩余长度字段的第一个字节的最高位为1，那么意味着剩余长度至少还有1个字节，然后继续读下一个字节，下一个字节的最高位为0，那么剩余长度字段到此为止，一共2个字节。
不同长度的剩余长度字段可以标识的长度如下表所示

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614243231469.png" alt="1614243231469" style="zoom:80%;" />



所以，这4个字节最多可以标识的包长度为：（0xFF,0xFF,0xFF,0x7F）=268 435 455字节，

**即256MB，这是MQTT协议中数据包的最大长度。**



# 4 MQTT协议详解

本章将从MQTT协议连接的建立开始，逐一讲解MQTT 3.1.1的各个特性，同时介绍MQTT 5.0的新特性



## 4.1 建立到Broker的连接


Client在可以发布和订阅消息之前，必须先连接到Broker。Client建立连接的流程如图4-1所示。

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614243475911.png" alt="1614243475911" style="zoom:80%;" />



1）Client向Broker发送一个CONNECT数据包；
2）Broker在收到Client的CONNECT数据包后，如果允许Client接入，则回复一个CONNACK包，该CONNACK包的返回码为0，表示MQTT协议连接建立成功；如果不允许Client接入，也回复一个CONNACK包，该CONNACK包的返回码为一个非0的值，用来标识接入失败的原因，然后断开底层的TCP连接。



### 4.1.1 CONNECT数据包

CONNECT数据包的格式如下。

#### 固定头

CONNECT数据包的固定头格式

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614243649759.png" alt="1614243649759" style="zoom:80%;" />

固定头中的MQTT协议数据包类型字段的值为1，代表CONNECT数据包。



#### 可变头

可变头由4部分组成，依次为：协议名称、协议版本、连接标识和Keepalive。

协议名称是一个UTF-8编码字符串。在MQTT协议数据包中，字符串会有2个字节的前缀，用于标识字符串的长度。

##### 协议名称

   协议名称的值固定为“MQTT”，加上前缀一共6个字节

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614243886368.png" alt="1614243886368" style="zoom:80%;" />

如果协议名称不正确，Broker会断开与Client的连接。



注：ASCII字符值：（查看地址：http://ascii.911cha.com）

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614244215737.png" alt="1614244215737" style="zoom:80%;" />


##### 协议版本

协议版本长度为1个字节，是一个无符号整数，MQTT 3.1.1的版本号为4

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614244484044.png" alt="1614244484044" style="zoom:80%;" />

##### 连接标识

连接标识长度为1个字节，字节中不同的位用于标识不同的连接选项

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614245126930.png" alt="1614245126930" style="zoom:80%;" />

每一个标识位的含义如下所示。

- 用户名标识（User Name Flag）：标识消息体中是否有用户名字段，长度为1bit，值为0或1；
- 密码标识（Password Flag）：标识消息体中是否有密码字段，长度为1bit，值为0或1；
- 遗愿消息Retain标识（Will Retain）：标识遗愿消息是否是Retain消息，长度为1bit，值为0或1；
- 遗愿消息QoS标识（Will QoS）：标识遗愿消息的QoS，长度为2bit，值为0、1或2。
- 遗愿标识（Will Flag）：标识是否使用遗愿消息，长度为1bit，值为0或1；
- 会话清除标识（Clean Session）：标识Client是否建立一个持久化的会话，长度为1bit，值为0或1。当Clean   Session的标识设为0时，代表Client希望建立一个持久会话的连接，Broker将存储该Client订阅的主题和未接受的消息，否则Broker不会存储这些数据，并在建立连接时清除这个Client之前存在的持久会话所保存的数据。



##### 连接保活设置

**可变头的最后2个字节代表**连接的Keepalive，即连接保活设置

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614245589565.png" alt="1614245589565" style="zoom:80%;" />

Keepalive代表一个单位为秒的时间间隔，Client和Broker之间在这个时间间隔之内至少要有一次消息交互，否则Client和Broker会认为它们之间的连接已经断开。我们会在4.4节中进行详细讲解



#### 消息体

CONNECT数据包的消息体依次由5个字段组成：

客户端标识符、

遗愿主题、

遗愿QoS、

遗愿消息、

用户名

密码

除了客户端标识符外，其他4个字段都是可选的，由可变头里对应的连接标识来决定是否包含在消息体中。



这些字段有一个2个字节的前缀，用来标识字段值的长度

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614245787581.png" alt="1614245787581" style="zoom:80%;" />



- 客户端标识符（Client Identifier）：Client Identifier是用来标识Client身份的字段，在MQTT 3.1.1中，这个字段的长度是1～23个字节，而且只能包含数字和26个英文字母（包括大小写），Broker通过这个字段来区分不同的Client。连接时，Client应该保证它的Identifier是唯一的，通常我们可以使用UUID、唯一的设备硬件标识或者Android设备的DEVICE_ID等作为Client Identifier的取值来源。

  MQTT协议中要求Client连接时必须带上Client Identifier，但也允许Broker在实现时接受Client Identifier为空的CONNECT数据包，这时Broker会为Client分配一个内部唯一的Identifier。如果你需要使用持久性会话，那就必须自己为Client设定一个唯一的Identifier。

  

- 用户名（Username）：如果可变头中的用户名标识为1，那么消息体中将包含用户名字段，Broker可以使用用户名和密码对接入的Client进行验证，只允许已授权的Client接入。注意，不同的Client需要使用不同的Client Identifier，但它们可以使用同样的用户名和密码进行连接。
  ·
- 密码（Password）：如果可变头中的密码标识为1，那么消息体中将包含密码字段



- 遗愿主题（Will Topic）：如果可变头中的遗愿标识为1，那么消息体中将包含遗愿主题。当Client非正常地中断连接时，Broker将向指定的遗愿主题发布遗愿消息。

  

- 遗愿消息（Will Message）：如果可变头中的遗愿标识为1，那么消息体中将包含遗愿消息。当Client非正常地中断连接时，Broker将向指定的遗愿主题发布由该字段指定的内容。



### 4.1.2 CONNACK数据包

当Broker收到Client的CONNECT数据包后，将检查并校验CONNECT数据包的内容，然后给Client回复一个CONNACK数据包。

CONNACK数据包的格式如下



#### 固定头

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614246118544.png" alt="1614246118544" style="zoom:80%;" />

当固定头中的MQTT数据包的类型字段值为2时，则代表该数据包是CONNACK数据包。CONNACK数据包剩余长度固定为2



#### 可变头

CONNACK数据包的可变头为2个字节，由连接确认标识和连接返回码组成，如图所示

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614246221313.png" alt="1614246221313" style="zoom:80%;" />

- 连接确认标识：

  - 连接确认标识的前7位都是保留的，必须设为0，

  - 最后一位是会话存在标识（Session Present Flag），值为0或1。当Client在连接时设置Clean Session=1，则CONNACK中的Session Present Flag始终为0；当Client在连接时设置Clean Session=0，那就有两种情况——如果Broker保存了这个Client之前留下的持久性会话，那么CONNACK中的Session Present Flag值为1；如果Broker没有保存该Client的任何会话数据，那么CONNACK中的Session Present Flag值为0。
    

- 连接返回码

  连接返回码（Connect Return Code）：用于标识Client与Broker的连接是否建立成功。

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614248347250.png" alt="1614248347250" style="zoom:80%;" />

这里重点讲一下Return Code 4和Return Code 5。

- Return Code 4在MQTT协议中的含义是用户名（Username）或密码（Password）的格式不正确，但是在大部分的Broker实现中，在使用错误的用户名或密码时，得到的返回码也是4。所以，这里我们认为4代表错误的用户名或密码。

- Return Code 5一般在Broker不使用用户名和密码而使用IP地址或者Client Identifier进行验证的时候使用，用来标识Client没有通过验证。

  

Return Code 2代表Client Identifier格式不规范，比如长度超过23个字符、包含了不允许的字符等（部分Broker的实现在协议标准上做了扩展，比如允许超过23个字符的Client Identifer等）。



#### 消息体

​          CONNACK数据包没有消息体。



当Client向Broker发送CONNECT数据包并获得Return Code为0的CONNACK包后，就代表连接建立成功，可以发布和订阅消息了



### 4.1.3  关闭连接

接下来我们看一下MQTT协议的连接是如何关闭的。MQTT协议的连接关闭可以由Client或Broker二者任意一方发起。



#### Client主动关闭连接

Client主动关闭连接的流程非常简单，只需要向Broker发送一个DISCONNECT数据包就可以了。



#### Broker主动关闭连接

MQTT协议规定Broker在没有收到Client的DISCONNECT数据包之前都应该保持和Client的连接，只有Broker在Keepalive的时间间隔里，没有收到Client的任何MQTT协议数据包时才会主动关闭连接。一些Broker的实现在MQTT协议上做了一些拓展，支持Client的连接管理，可以主动断开和某个Client的连接。

Broker主动关闭连接之前不需要向Client发送任何MQTT协议数据包，直接关闭底层的TCP连接就可以。



### 4.1.4  代码实践

接下来，我们将用代码来展示各种情况下MQTT协议连接的建立以及断开



在这里，我们使用 [MQTTne](https://github.com/chkr1011/MQTTnet) 的MQTT库

这里使用一个公共的Broker：mqtt.eclipse.org。

```html
https://mqtt.eclipseprojects.io/

mqtt.eclipseprojects.io
This is a public test MQTT broker service. It currently listens on the following ports:

1883 : MQTT over unencrypted TCP
8883 : MQTT over encrypted TCP
80 : MQTT over unencrypted WebSockets (note: URL must be /mqtt )
443 : MQTT over encrypted WebSockets (note: URL must be /mqtt )
```





参考资料：

https://github.com/chkr1011/MQTTnet/wiki/Client

https://blog.csdn.net/li2008kui/article/details/78339309

https://github.com/chkr1011/MQTTnet/wiki

http://www.360doc.com/content/21/0108/20/38894361_955914772.shtml



#### 示例: 建立持久性会话

***代码清单: src/Charpter-03/PersistentConnection.csproj***

```C#
class Program
{
    static void Main(string[] args)
    {
        // Create a new MQTT client.
        var factory = new MqttFactory();
        var mqttClient = factory.CreateMqttClient();

        try
        {
            // Use TCP connection.
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("mqtt.eclipseprojects.io", 1883) // Port is optional
                .WithClientId("mqtt_sample_id_keep_session")

                //false:建立一个持久会话的连接,Broker将存储该Client订阅的主题和未接受的消息
                .WithCleanSession(false)

                .Build();

            mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnAppMessage);
            mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
            mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);

            mqttClient.ConnectAsync(options).Wait();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"连接到MQTT服务器失败！" + Environment.NewLine + ex.Message + Environment.NewLine);
        }

        Console.WriteLine($"输入任意键退出");
        Console.ReadKey();
    }


    private static void OnAppMessage(MqttApplicationMessageReceivedEventArgs e)
    {
    }

    private static void OnConnected(MqttClientConnectedEventArgs e)
    {
        Console.WriteLine("已连接到MQTT服务器！");

        //建立一个持久会话的连接,CONNACK中的Session Present Flag值
        //第一次连接成功后，其值为：0
        //第N次（N>=2）连接后,其值为一直为:1
        Console.WriteLine($"MqttClientConnectedEventArgs:{Environment.NewLine}{JsonConvert.SerializeObject(e)}");
    }

    private static void OnDisconnected(MqttClientDisconnectedEventArgs e)
    {
        Console.WriteLine("连接已经断开！");
    }

}
```



建立一个持久会话的连接,CONNACK中的Session Present Flag值

第一次连接成功后，其值为：0

第N次（N>=2）连接后,其值为一直为:1



#### 示例: 建立非持久性会话

***代码清单: src/Charpter-03/NoPersistentConnection.csproj***

```C#
  class Program
    {
        static void Main(string[] args)
        {
            // Create a new MQTT client.
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            try
            {
                // Use TCP connection.
                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer("mqtt.eclipseprojects.io", 1883) // Port is optional
                    .WithClientId("mqtt_sample_id_clean_session")
                    .WithCleanSession(true) //false:建立一个持久会话的连接，Broker不存储该Client订阅的主题和未接受的消息
                    .Build();

                mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnAppMessage);
                mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
                mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);

                mqttClient.ConnectAsync(options).Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"连接到MQTT服务器失败！" + Environment.NewLine + ex.Message + Environment.NewLine);
            }

            Console.WriteLine($"输入任意键退出");
            Console.ReadKey();
        }


        private static void OnAppMessage(MqttApplicationMessageReceivedEventArgs e)
        {
        }

        private static void OnConnected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("已连接到MQTT服务器！");

            //非持久性会话， Session Present Flag 永远是 False
            Console.WriteLine($"MqttClientConnectedEventArgs:{Environment.NewLine}{JsonConvert.SerializeObject(e)}");
        }

        private static void OnDisconnected(MqttClientDisconnectedEventArgs e)
        {
            Console.WriteLine("连接已经断开！");
        }

    }
```



非持久性会话， Session Present Flag 永远是 False



#### 示例: 使用相同的客户端标识进行连接

***代码清单: src/Charpter-03/Identical.csproj***

```C#
class Program
    {
        static void Main(string[] args)
        {
            // Create a new MQTT client.
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            try
            {
                // Use TCP connection.
                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer("mqtt.eclipseprojects.io", 1883) // Port is optional
                    .WithClientId("mqtt_sample_id_identical")
                    //false:建立一个持久会话的连接,Broker将存储该Client订阅的主题和未接受的消息
                    .WithCleanSession(false)

                    .Build();

                mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnAppMessage);
                mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
                mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);

                mqttClient.ConnectAsync(options).Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"连接到MQTT服务器失败！" + Environment.NewLine + ex.Message + Environment.NewLine);
            }

            Console.WriteLine($"输入任意键退出");
            Console.ReadKey();
        }


        private static void OnAppMessage(MqttApplicationMessageReceivedEventArgs e)
        {
        }

        private static void OnConnected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("已连接到MQTT服务器！");
            Console.WriteLine($"MqttClientConnectedEventArgs:{Environment.NewLine}{JsonConvert.SerializeObject(e)}");
        }

        private static void OnDisconnected(MqttClientDisconnectedEventArgs e)
        {
            Console.WriteLine("连接已经断开！");
        }

    }
```



在MQTT协议中，两个Client使用相同的Client Identifier（该示例中其值为：mqtt_sample_id_identical）进行连接时，如果第二个Client连接成功，Broker会关闭与第一个Client的连接。

<img src="images/%E7%89%A9%E8%81%94%E7%BD%91%E7%B3%BB%E7%BB%9F%E5%BC%80%E5%8F%91Iot%E5%B9%B3%E5%8F%B0/1614265567685.png" alt="1614265567685" style="zoom:80%;" />