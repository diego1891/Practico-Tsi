export const BASE_URL = "http://localhost:5208/api/Usuarios";

const fetchUsuario = async (alias) => {
  const URL = `${BASE_URL}/todos/${alias}`;
  let data, usuario;
  try {
    const response = await fetch(URL);
    data = await response.json();
    if (data.length > 0) {
        usuario = data[0];
        console.log("Usuario:", usuario);
      } else {
        console.log("Usuario no encontrado");
      }
  } catch {
    console.log("Error en el fetch");
  }
  return usuario
};

export{fetchUsuario}
