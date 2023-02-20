var cliente1=new Cliente(){Nro_Telefono="12345"};
var cliente2=new Cliente(){Nro_Telefono="58283"};
var cliente3=new Cliente(){Nro_Telefono="92938"};
var cliente4=new Cliente(){Nro_Telefono="15215"};

var inmobiliaria1=new Inmobiliaria(){Mail="inmo1@gmail.com"};
var inmobiliaria2=new Inmobiliaria(){Mail="inmo2@gmail.com"};
var inmobiliaria3=new Inmobiliaria(){Mail="inmo3@gmail.com"};
var inmobiliaria4=new Inmobiliaria(){Mail="inmo4@gmail.com"};

var inmueble1=new Inmueble(100){Domicilio="Salta 123"};
var inmueble2=new Inmueble(200){Domicilio="Francia 578"};

inmueble1.Conectar(inmobiliaria1,cliente1);
inmueble1.Conectar(inmobiliaria1,cliente2);
inmueble1.CambiarPrecio(300);
inmobiliaria1.Responder(inmueble1);

public abstract class Interesado{
    public string? Nombre{get;set;}
    public string? Mail{get;set;}

    public abstract void Responder(Inmueble inmu);
    public virtual void Agregar(Interesado interesado){
        throw new NotImplementedException();
    }
    
}

public class Inmobiliaria:Interesado{
    public double PorcentajeComision{get;set;}
    private List<Interesado> interesados=new List<Interesado>();
    public override void Agregar(Interesado interesado){
        interesados.Add(interesado);
    }
    public override void Responder(Inmueble inm)
    {
            Console.WriteLine($"Hemos recibido un mail a nuestra casilla {this.Mail} con el mensaje:  Domicilio: {inm.Domicilio} Nuevo Precio: {inm.Precio}");
            foreach (var component in interesados)
            {
                component.Responder(inm);
            }
    }
}

public class Cliente:Interesado{
    public string? Nro_Telefono{get;set;}

    public override void Responder(Inmueble inm)
    {
        Console.WriteLine($"He recibido un SMS en mi teléfono {this.Nro_Telefono} con el mensaje: Domicilio: {inm.Domicilio} Nuevo Precio: {inm.Precio}");
    }
}

public class Inmueble{
    public Inmueble(double Precio){
        this.Precio=Precio;
    }
    public string? Domicilio{get;set;}
    public double Superficie{get;set;}
    public int CantAmbientes {get;set;}

    public double Precio{get;private set;}

    public void CambiarPrecio(double nuevoPrecio){
        this.Precio=nuevoPrecio;
        
    }
    public void Conectar(Interesado component1, Interesado component2)
    {
            if (component1 is Inmobiliaria)
            {
                component1.Agregar(component2);
            }
            
            //Console.WriteLine($"RESULT: {component1.Responder()}");
    }
}