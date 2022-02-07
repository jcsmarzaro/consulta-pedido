# Consulta-Pedido-Operacao
Projeto desenvolvido para que a torre de controle possa realizar a consulta do XML de pedido de venda no Millennium após a nova forma de autenticação (token) ser implementada no Millennium pela Linx.

## Autenticação
O token de autenticação é obtido através de uma consulta no <i>integrador</i>. Que realiza o processo de cache do Millennium.

Endpoint de consulta de token:
```
https://new-integrator.selia.com.br/selia/get-order
```

## Container/Deploy
Na raíz do projeto temos o Dockerfile. Para buildarmos o projeto devemos executar o seguinte comando:
```
docker build -t <repository>/<project> --no-cache .
```

Após o build da imagem devemos executar o seguinte comando para executar o projeto:
```
docker run -p 80:80 -d <image>
```

<b>OBS:</b> A porta 80 sempre deve ser exposta.