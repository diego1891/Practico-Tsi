import React, { useState, useEffect } from "react";
import "./Usuario.css";

function Usuarios({ usuario, status }) {
  console.log("usuario en coso " + usuario);
  console.log("usuario:", JSON.stringify(usuario, null, 2));

  if (!usuario) {
    return <div className="waiting">Cargando...</div>;
  } else {
    return (
      <div className="carta">
        <h2>Información del Usuario</h2>
        <div>
          <strong>Nombre:</strong> {usuario.nombre}
        </div>
        <div>
          <strong>Edad:</strong> {usuario.alias}
        </div>
        <div>
          <strong>Email:</strong> {usuario.email}
        </div>
        <strong>Biografia:</strong> {usuario.biografia}
      </div>
    );
  }
}
export default Usuarios;
