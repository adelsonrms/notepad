## notepad
Apenas para anotações gerais


Notas e Informaçções uteis :

# Comandos uteis 

Registrar variavel de ambiente global e persistente (nao apaga com a inicialização)

Para todos os usuarios :

Executar o script em um terminal

```powershell
# Executar os comandos abaixo

# Definir diretório padrão dos repositórios em nuvem
$env:src = "F:\Cloud\OneDrive\source"
setx src "F:\Cloud\OneDrive\source"

# Definir repositórios do GitHub
$env:github = "F:\Cloud\OneDrive\source\github"
setx github "F:\Cloud\OneDrive\source\github"

# Definir repositórios do Azure DevOps
$env:devops = "F:\Cloud\OneDrive\source\devops"
setx devops "F:\Cloud\OneDrive\source\devops"


```

```csharp
// Este é um código C#
public class Exemplo
{
    public void Metodo()
    {
        Console.WriteLine("Hello, Markdown!");
    }
}
```
