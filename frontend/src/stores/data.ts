import {defineStore} from "pinia";
import init from '../../data.json'


export const useDataStore = defineStore('data', {
    state: () => {
        return {
            plain: '10101010',
            secret: '1010101010',
            flow: init,
        }
    },
    actions: {
        setPlain(val: string) {
            const maxPlainLength = 8
            this.plain = this.normalize(maxPlainLength, val)
            this.update()
        },

        setSecret(val: string) {
            const maxSecretLength = 10
            this.secret = this.normalize(maxSecretLength, val)
            this.update()
        },
        normalize(length: number, value: string) {
            const initLength = value.length
            if (initLength < length)
                for (let i = 0; i < length - initLength; i++)
                    value += "0"
            return value
        },

        update() {
            const url = "https://localhost:7039"

            const requestOptions = {
                method: 'GET',
                redirect: 'follow'
            };

            // @ts-ignore
            fetch(`${url}/Main?p=${this.plain}&k=${this.secret}`, requestOptions)
                .then((response) => response.json())
                .then((data) => {
                    this.flow = data
                })
                .catch(error => console.log('error', error));
        }
    }
})


