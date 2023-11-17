import React, { useState, useRef } from "react";
import { fetchUsuario } from "../../services/fetch";
import "./header.css";

const Header = ({ setUsuario, setStatus }) => {
  const inputRef = useRef(null);

  let inputValue;
 
  let handleEnter = async (event) => {
    if (event.key === 'Enter') {
      inputValue = event.target.value;
      let response = await fetchUsuario(inputValue);
      setUsuario(response);
      console.log("data:", JSON.stringify(response, null, 2));
      setStatus(true);
      event.target.value = '';
    }
  };

  const handleClick = async () => {
    if (inputRef.current.value) {
      let response = await fetchUsuario(inputValue);
      setUsuario(response);
      setStatus(true);
      inputRef.current.value = '';
    }
  };

  return (
    <div className='header'>
        <div className='logo'>Practico-Tsi</div>
      <div className='search-bar'>
        <input
          type='text'
          placeholder='Buscar...'
          value={inputValue}
          ref={inputRef}
          onKeyDown={handleEnter}
        />
        <button onClick={() => handleClick()}>Buscar</button>
      </div>
    </div>
  );
};

export default Header;