## Como se referenciar game objects. Cinco formas
Feito a partir de vídeo:
https://www.youtube.com/watch?v=ymq2AUckws0
O mais utilizado é a referência a partir de instância. Mas a que ele mais gosta é a por injeção de dependência.

###  1: Referência direta a partir da UI:
Nessa forma de referência é importante se usar esse método para que não haja variáveis públicas indevidas. Usando a primeira linha do exemplo abaixo é possível mostrar na interface variáveis privadas.

[SerializeField]
private ScoreManager objeto_nome;

O problema com este método é que se eu tiver 100 objetos deste eu teria de setar isto para cada um destes, e se eu tiver múltiplas cenas eu teria de setar também individualmente para cada uma delas. Isso fere a escalabilidade do projeto. Apesar de prefabs permitirem o salvamento dessa configuração, isso só é possível com referências também de dentro do prefab.

### 2: Referência a partir de "tipo":
Outra forma é usar uma função do unity para achar um objeto a partir do tipo:

FindObjectOfType<ScoreManager>().AddScore(1);

Ele procura por objetos com esse tipo na cena e pega o primeiro (de cima pra baixo).
Esse método é muito bom para referenciar scripts presentes em prefabs que foram gerados por um Spawner ou algo assim.

### 3: Referência a partir de instância
A forma  como a referência é chamada é a seguinte (do objeto que chama a função do referenciado):

ScoreManager2.Instance.AddScore(1);

E no objeto referenciado a construção é feita assim:

Public static ScoreManager2 Instance {get; private set;}

private void Awake()
{
    
    if (Instance == null)
    {
        Instance = this;
    }
    else
    {
        Destroy(gameObject);       //don't allow 2 scoremanagers
    }
}

public void AddScore(int amount)
{
    score += amount;
}

Observa-se que essa instancia tem o tipo de mesmo nome da classe onde ela está. Ela tem um get publico e um set privado, para que ela seja montada só na classe mãe, mas suas funções possam ser alcançadas de outras classes.
Outra coisa importante é que essa instância seja criada só uma vez, assim, por isso a condicional na função Awake. Isso não significa que ela só possa ser chamada uma vez, só que só existirá uma instancia. (Se houver dois Game Objects na cena com essa classe, um deles seria destruído). 

### 4: Using a Scriptable object
Using a Scriptable Object other than a Mono Behavior, is possible to create objects in the format of files in the file manager. The script must have:

[CreateAssetMenu(menuName = "ScoreManager")]

public class ScoreManager3 : ScriptableObject
{
    private int score;

    private void OnEnable()
    {
        score = 0;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}

O interessante é que essa classe existe fora do objeto e os valores armazenados nela sobrevivem a novas cenas por exemplo. Assim é importante fazer um reset de seus valores quando habilitada (OnEnable). A primeira linha do script acima serve para que seja possível se criar no gerenciador de arquivos o objeto com o script. Assim, referenciamos isso nos objetos do jogo e nas referências a ele. O aspecto de não volátil torna esse tipo de memória boa para saves ou algo do tipo.

### 5: Dependency Injection
O método é baseado em se pegar dependências e se passar elas para objetos em tempo de execução. Para spawners isso é feito da seguinte forma:

GameObject.Initialize(scoreManager); //Isso passa essa dependência para dentro do objeto.

A referencia scoreManager pode ter sido criado com algum dos métodos dados anteriormente, mas o legal é que a instância é passada para os objetos criados pelo spawn. E as referências anteriormente estabelecidas são passadas também junto com o método.

