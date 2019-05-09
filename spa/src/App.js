import React from 'react';
import logo from './logo.svg';
import './App.css';
import 'rsuite/dist/styles/rsuite.min.css';
import { Button } from 'rsuite';
import FormComponent from "./Components/FormComponent";

function App() {
  return (
    <div className="App">
      <Button appearance="primary"> Hello world </Button>
      <FormComponent />
    </div>
  );
}

export default App;
