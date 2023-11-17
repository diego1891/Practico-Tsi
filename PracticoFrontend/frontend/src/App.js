import './App.css';
import Usuarios from './components/usuario/Usuarios'
import Header from './components/header/header'
import { useState } from 'react';

function App() {
  const [usuario, setUsuario] = useState(null);
  const [status, setStatus] = useState(false);
  return (
    <div className="App">
      <Header setUsuario={setUsuario} setStatus={setStatus}/>
      <Usuarios usuario={usuario} status={status}/>
    </div>
  );
}

export default App;
