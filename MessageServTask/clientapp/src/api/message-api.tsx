import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import axios from 'axios';
import React, { SetStateAction, useState } from 'react';
import { resourceLimits } from 'worker_threads';
import { MessageModel } from '../models/message-model'

// Get запрос для получения списка всех сообщений
const getMessagesApi =(setArg: (value: React.SetStateAction<MessageModel[]>) => void) => {
  axios
      .get("https://localhost:44359/api/messages", {
          headers: {
              "Content-Type": "application/json"
          },
      }).then(response => {
        console.log("response data ====>" ,response.data);
        setArg(response.data);
      })

}

//Удаление Post запросом, сообщений по списку
function deleteMessagesPostApi(messagesToDelete: MessageModel[]){
  return(axios.post('https://localhost:44359/api/delete_message', { messagesToDelete },{
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
      }}))
}

export { getMessagesApi, deleteMessagesPostApi }