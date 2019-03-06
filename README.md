<![endif]-->

# Общая часть

Наша задача: разработать IoC-контейнер (следуя принципу «Каждый программист должен разработать свой IoC/DI контейнер» © J).

В качестве примера мы возьмем Managed  Extensibility  Framework (MEF), в котором основная настройка контейнера происходит за счет расстановки атрибутов.

Но (!) весь код, включая объявление атрибутов у нас будет свой.

# Задание 1.

Используя механизмы Reflection, создайте простейший IoC-контейнер, который позволяет следующее:

<![if !supportLists]>· <![endif]>Разметить классы, требующие внедрения зависимостей одним из следующих способов

<![if !supportLists]>o <![endif]>Через конструктор (тогда класс размечается атрибутом [ImportConstructor])

[ImportConstructor]  
public  class  CustomerBLL  
{  
public CustomerBLL(ICustomerDAL dal, Logger logger)  
{ }  
}

<![if !supportLists]>o <![endif]>Через публичные свойства (тогда каждое свойство, требующее инициализации, размечается атрибутом [Import])

public  class  CustomerBLL {  
    [Import] public  ICustomerDAL CustomerDAL { get; set; }  
    [Import] public  Logger logger { get; set; }  
}

При этом, конкретный класс, понятное дело, размечается только одним способом!

<![if !supportLists]>· <![endif]>Разметить зависимые классы

<![if !supportLists]>o <![endif]>Когда класс используется непосредственно

[Export] public  class  Logger {  }

<![if !supportLists]>o <![endif]>Когда в классах, требующих реализации зависимости используется интерфейс или базовый класс

[Export(typeof(ICustomerDAL))] public  class  CustomerDAL : ICustomerDAL { }

<![if !supportLists]>· <![endif]>Явно указать классы, которые зависят от других или требуют внедрения зависимостей

var container = new  Container();  
container.AddType(typeof(CustomerBLL));  
container.AddType(typeof(Logger));  
container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));

<![if !supportLists]>· <![endif]>Добавить в контейнер все размеченные атрибутами [ImportConstructor], [Import] и [Export], указав сборку

var container = new  Container();  
container.AddAssembly(Assembly.GetExecutingAssembly());

<![if !supportLists]>· <![endif]>Получить экземпляр ранее зарегистрированного класса со всеми зависимостями

var customerBLL = (CustomerBLL)container.CreateInstance(

 typeof(CustomerBLL)); var customerBLL = container.CreateInstance<CustomerBLL>();<![endif]-->

# Общая часть

Наша задача: разработать IoC-контейнер (следуя принципу «Каждый программист должен разработать свой IoC/DI контейнер» © J).

В качестве примера мы возьмем Managed  Extensibility  Framework (MEF), в котором основная настройка контейнера происходит за счет расстановки атрибутов.

Но (!) весь код, включая объявление атрибутов у нас будет свой.

# Задание 1.

Используя механизмы Reflection, создайте простейший IoC-контейнер, который позволяет следующее:

<![if !supportLists]>· <![endif]>Разметить классы, требующие внедрения зависимостей одним из следующих способов

<![if !supportLists]>o <![endif]>Через конструктор (тогда класс размечается атрибутом [ImportConstructor])

[ImportConstructor]  
public  class  CustomerBLL  
{  
public CustomerBLL(ICustomerDAL dal, Logger logger)  
{ }  
}

<![if !supportLists]>o <![endif]>Через публичные свойства (тогда каждое свойство, требующее инициализации, размечается атрибутом [Import])

public  class  CustomerBLL {  
    [Import] public  ICustomerDAL CustomerDAL { get; set; }  
    [Import] public  Logger logger { get; set; }  
}

При этом, конкретный класс, понятное дело, размечается только одним способом!

<![if !supportLists]>· <![endif]>Разметить зависимые классы

<![if !supportLists]>o <![endif]>Когда класс используется непосредственно

[Export] public  class  Logger {  }

<![if !supportLists]>o <![endif]>Когда в классах, требующих реализации зависимости используется интерфейс или базовый класс

[Export(typeof(ICustomerDAL))] public  class  CustomerDAL : ICustomerDAL { }

<![if !supportLists]>· <![endif]>Явно указать классы, которые зависят от других или требуют внедрения зависимостей

var container = new  Container();  
container.AddType(typeof(CustomerBLL));  
container.AddType(typeof(Logger));  
container.AddType(typeof(CustomerDAL), typeof(ICustomerDAL));

<![if !supportLists]>· <![endif]>Добавить в контейнер все размеченные атрибутами [ImportConstructor], [Import] и [Export], указав сборку

var container = new  Container();  
container.AddAssembly(Assembly.GetExecutingAssembly());

<![if !supportLists]>· <![endif]>Получить экземпляр ранее зарегистрированного класса со всеми зависимостями

var customerBLL = (CustomerBLL)container.CreateInstance(

 typeof(CustomerBLL)); var customerBLL = container.CreateInstance<CustomerBLL>();
