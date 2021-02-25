# 说明

该示例是为了演示 Client与Broker 建立非持久性会话

第一次运行：
返回
return code: 0, sessionPresent: false

连接成功后，因为是客户端标识符为“mqtt_sample_id_1”的Client第一次建立连接，所以SessionPresent为false。

再次运行，输出就会变成SessionPresent。
return code: 0, sessionPresent: true

因为之前已经创建了一个持久会话，所以这次再使用同样的客户端标识符进行连接，得到的SessionPresent为true，表示会话已经存在了。

#知识点

## CONNECT数据

CONNECT数据包中的会话清除标识（Clean Session）：
    标识Client是否建立一个持久化的会话，长度为1bit，值为0或1。当Clean   Session的标识设为0时，
代表Client希望建立一个持久会话的连接，Broker将存储该Client订阅的主题和未接受的消息，
否则Broker不会存储这些数据，并在建立连接时清除这个Client之前存在的持久会话所保存的数据。
*/
.WithCleanSession(false) //false:建立一个持久会话的连接，Broker将存储该Client订阅的主题和未接受的消息


## CONNACK数据包：

当Client在连接时设置Clean Session=1，则CONNACK中的Session Present Flag始终为0；
当Client在连接时设置Clean Session=0，那就有两种情况
    1. 如果Broker保存了这个Client之前留下的持久性会话，那么CONNACK中的Session Present Flag值为1；
    2. 如果Broker没有保存该Client的任何会话数据，那么CONNACK中的Session Present Flag值为0。