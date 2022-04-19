import axios from "axios";
import React, { useState } from "react";
import { getMessagesApi, deleteMessagesPostApi } from "../api/message-api";
import { MessageModel } from "../models/message-model";

import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import { argv } from "process";
import { Button } from "@mui/material";


const MyComponent = () => {
    const forUse: MessageModel[] = [];
    const [messages, setMessages] = useState(forUse)
    const [state, setState] = useState(false);
    const [messagesDeleteList, setMessagesDeleteList] = useState([]);


    //обработчик кнопки
    const handleDeleteMessage = () => {
        deleteMessagesPostApi(messagesDeleteList).then(() => {
            setMessagesDeleteList([]);
            setMessages([]);
            getMessagesApi(setMessages);
        })
    }

    //Функция для onChange. Чтобы отмечать item`ы и помещать нужные в list для удаления
    function toDelete(e, item) {
        console.log(e.target.checked)
        if (e.target.checked) {
            messagesDeleteList.push(messages[item]);
        }
        else {
            const index = messagesDeleteList.indexOf(messages[item], 0);
            if (index > -1) {
                messagesDeleteList.splice(index, 1);
            }
        }
        setState(e.target.checked);
    }

    // UseEffect для получения списка сообщений при загрузке
    React.useEffect(() => {
        
        getMessagesApi(setMessages);
    }, []);



    return <>{(Object.keys(messages).map(item =>
        <FormGroup>
            <FormControlLabel control={<Checkbox />} defaultChecked={false} label={messages[item].fromUser} value={messages[item].body}
                onChange={e => {
                    toDelete(e, item);
                }} ></FormControlLabel>
                {messages[item].body}

        </FormGroup>
        
    ))}
        <Button variant="text" onClick={() => handleDeleteMessage()}>Удалить</Button>
    </>

}
export { MyComponent }

