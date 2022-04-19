import React from 'react';
import logo from './logo.svg';
import './App.css';

import { useState } from 'react';
import { skipToken } from '@reduxjs/toolkit/dist/query';
import {MyComponent} from './components/ListMessages'

function App() {
  
  return (
    <div >
      <MyComponent/>
    </div>
  );
}

export default App;
