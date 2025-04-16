# Implantação de Aplicação ASP.NET Core em VPS Linux Ubuntu

**Data**: 16/04/2025  
**Ambiente**: Ubuntu VPS (Hostinger), domínio externo (GoDaddy), NGINX como proxy reverso.

---

## ✅ Pré-requisitos

- VPS com Ubuntu 22.04+ (com acesso root via SSH)
- Domínio registrado e gerenciável (ex: GoDaddy)
- Aplicação ASP.NET Core publicada para Linux
- Docker e Portainer (opcional)

---

## 🧰 Passos de Instalação e Configuração

### 1. Conectar na VPS
```bash
ssh root@<IP_DA_VPS>
```

---

### 2. Instalar o .NET SDK e Runtime (.NET 8)
```bash
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt update
sudo apt install -y dotnet-sdk-8.0 aspnetcore-runtime-8.0
```

---

### 3. Publicar aplicação ASP.NET Core (no Windows)
```bash
dotnet publish -c Release -r linux-x64 --self-contained false -o ./publish
```

Transferir os arquivos via SCP:
```bash
scp -r ./publish root@<IP_DA_VPS>:/var/www/worc
```

---

### 4. Criar serviço systemd
Criar `/etc/systemd/system/worc.service`:

```ini
[Unit]
Description=Aplicação ASP.NET Core WORC
After=network.target

[Service]
WorkingDirectory=/var/www/worc
ExecStart=/usr/bin/dotnet /var/www/worc/SeuApp.dll
Restart=always
RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=worc-app
User=www-data
Environment=ASPNETCORE_ENVIRONMENT=Production

[Install]
WantedBy=multi-user.target
```

```bash
sudo systemctl daemon-reexec
sudo systemctl daemon-reload
sudo systemctl enable worc.service
sudo systemctl start worc.service
```

---

### 5. Instalar NGINX
```bash
sudo apt install nginx
```

---

### 6. Configurar NGINX com proxy reverso
Criar `/etc/nginx/sites-available/worc`:

```nginx
server {
    listen 80;
    server_name worc.armscorp.com.br;

    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}
```

```bash
sudo ln -s /etc/nginx/sites-available/worc /etc/nginx/sites-enabled/
sudo nginx -t
sudo systemctl reload nginx
```

---

### 7. Configurar DNS no provedor (GoDaddy)
Apontar um registro **A** para `worc.armscorp.com.br` com o IP da VPS.

---

### 8. (Opcional) Executar n8n via Docker + Portainer
- Criar container n8n e redirecionar porta 5678
- Exemplo: `5678:5678` (e **não** `80:5678`)

Configurar NGINX para `n8n.armscorp.com.br`:

```nginx
server {
    listen 80;
    server_name n8n.armscorp.com.br;

    location / {
        proxy_pass http://localhost:5678;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}
```

---

## 🟢 Finalizando

Acesse a aplicação:
```
http://worc.armscorp.com.br
```

E o serviço n8n (se configurado):
```
http://n8n.armscorp.com.br
```

---

## 📌 Extras sugeridos

- [ ] Instalar HTTPS com Let's Encrypt + Certbot
- [ ] Automatizar deploy com Git ou GitHub Actions
- [ ] Configurar backup e monitoramento
