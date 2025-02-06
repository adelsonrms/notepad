## PowerShell - Dicas e conceitos

# Conceitos Gerais.

É um runtime (executor) de código Script (Sequencia de comandos em texto puro). Similar ao Batch, VBCript, JavaScript, entre outros...

Suporta todos os comandos do CMD (DOS) ou Prompt de Comando.


# Alguns comandos .

wget : Realiza uma requisição web utilizado o metodo GET. 

Obs. Esse comando internamente utiliza o ``cmdlet Invoke-WebRequest``

```powershell
# Baixa o conteudo retornado pela url.

wget www.google.com.br

```
