import React from 'react';
import './App.css';
import Header from './components/Header'
import Main from './components/Main';

const style={
  main:{
    margin:0, padding:0, width:'100vw', height:'100vh',
    background: 'rgb(2,0,36)',
    background: 'linear-gradient(350deg, rgba(2,0,36,1) 0%, rgba(30,29,29,1) 44%, rgba(45,43,43,1) 100%)',
    color:'white'
  }
}

function App (){
  return (
    <div className="App" style={style.main}>
      <div>
        <Header/>
        <div className="container-fluid mt-5">
          <Main />
        </div>
      </div>
    </div>
  )
}

export default App;
