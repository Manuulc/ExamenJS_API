window.onload = inicializaEventos;

var arrayDeGentuza
var departamentos
/**
 * Funcion que se ejecutara nada mas abrir la pagina
 * */
function inicializaEventos() {

    ObtenerPersonasAPI();
    ObtenerDepartamentosAPI();
    document.getElementById("btnGuardar").addEventListener("click", ActualizarPersonas, false);
}


/**
 * Funcion para obtener los departamentos de mi API
 * */
function ObtenerDepartamentosAPI() {

    var miLlamada = new XMLHttpRequest(); //Punto 1
    var div = document.getElementById("stateDepartamentos");
    miLlamada.open("GET", "http://localhost:5097/api/departamentos",false); //Punto 2

    //Definicion estados

    miLlamada.onreadystatechange = function () {                  

        if (miLlamada.readyState < 4) {

            div.innerHTML = "Cargando...";

        }

        else if (miLlamada.readyState == 4 && miLlamada.status == 200) {

                departamentos = JSON.parse(miLlamada.responseText);

            }
    };
    
    miLlamada.send();   //Paso 5

   
}


/**
 * Funcion para obtener las personas con departamento de mi API*/
function ObtenerPersonasAPI() {

    
    var miLlamada = new XMLHttpRequest(); //Punto 1
    var state = document.getElementById("statePersonas");
    miLlamada.open("GET", "http://localhost:5097/api/personas"); //Punto 2

    //Definicion estados

    miLlamada.onreadystatechange = function () {                  //Esta es una función anónima. Paso 4

        if (miLlamada.readyState < 4) {

            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
            state.innerHTML = "Cargando...";

        }

        else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            state.innerHTML = ""
            arrayDeGentuza = JSON.parse(miLlamada.responseText); // obtengo a todas las personas
            LlenarTabla();
        }
    };

    miLlamada.send();   //Paso 5

}


/**
 * Funcion para llenar la tabla de personas con nombre,apellidos y nombre del departamento.
 * 
 * Iteramos sobre el array de personas para crear el cuerpo de la tabla, creando una fila (tr) y su contenido (td) cada vez que iteramos en el for.
 * En el contenido vamos metiendo el nombre, apellidos y nombre del departamento de las personas, y añadiendo a la fila este contenido
 * Al cuerpo de la tabla le añadimos la fila una vez hayamos rellenado todos los campos.
 * Finalmente añadimos a la tabla el cuerpo que hemos creado con el for.
 * 
 * Precondiciones: debemos tener acceso a la api
 * Postcondiciones: se crea una tabla
 * 
 * @param {any} arrayDeGentuza
 */
function LlenarTabla() {

    let tabla = document.getElementById("personas") // Obtenemos la tabla del html
    let bodyTabla = document.createElement("tbody") // y creo el cuerpo para la tabla

    for (var i = 0; i < arrayDeGentuza.length; i++) {

        //console.log(arrayDeGentuza[i].nombre)
        let fila = document.createElement("tr") // creo una fila

        let contenido = document.createElement("td") // creo el elemento para el contenido
        contenido.innerText = arrayDeGentuza[i].nombre // en el contenido meto el nombre
        fila.appendChild(contenido) // y en la fila meto el contenido

        contenido = document.createElement("td") // creo otro elemento para el contenido
        contenido.innerText = arrayDeGentuza[i].apellidos // y repito lo de arriba
        fila.appendChild(contenido)

        var select = document.createElement("select")
        select.id = arrayDeGentuza[i].idPersona;

        // en este for recorro el array de departamentos para crear el select para cada persona
        for (var j = 0; j < departamentos.length; j++) {
            var opcion = document.createElement("option");
            opcion.value = departamentos[j].idDepartamento;
            opcion.innerHTML = departamentos[j].nombreDepartamento;
            if (arrayDeGentuza[i].idDepartamento == departamentos[j].idDepartamento) {
                opcion.selected = true;
            }

            select.appendChild(opcion)
        }

        contenido = document.createElement("td")
        fila.appendChild(contenido)
        contenido.appendChild(select)

        bodyTabla.appendChild(fila) // al cuerpo de la tabla le meto la fila
    }

    tabla.appendChild(bodyTabla) // a la tabla le meto el cuerpo de la tabla (tbody)
}

/**
 * Funcion que actualiza las personas en las que los selects de los departamentos hayan cambiado de value
 * 
 * */
function ActualizarPersonas() {

    var actualizados = 0;
    
    for (var i = 0; i < arrayDeGentuza.length; i++) {

        var select = document.getElementById(arrayDeGentuza[i].idPersona); // voy obteniendo los selects de cada persona
        if (arrayDeGentuza[i].idDepartamento != select.value) { // compruebo si el id del departamento de esa persona es distinto del que tenia antes
            var miLlamada = new XMLHttpRequest();
            arrayDeGentuza[i].idDepartamento = select.value; // le asigno al value del select el nuevo id del departamento
            var json = JSON.stringify(arrayDeGentuza[i]); // paso a json solo esa persona
            miLlamada.open("PUT", "http://localhost:5097/api/personas");
            miLlamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');
            miLlamada.send(json);
            actualizados++;
        }
    }
    var divPersonasActualizadas = document.getElementById("divPersonasActualizadas");
    divPersonasActualizadas.innerHTML = "Actualizadas " + actualizados + " personas";
    divPersonasActualizadas.style.color = "green"
}

class Persona {
    constructor(id, nombre, apellidos, telefono, direccion, foto, fechaNacimiento, idDepartamento) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.telefono = telefono;
        this.direccion = direccion;
        this.foto = foto;
        this.fechaNacimiento = fechaNacimiento;
        this.idDepartamento = idDepartamento;
    }
}

