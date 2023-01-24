import { type ViteSSGContext } from 'vite-ssg'

export type UserModule = (ctx: ViteSSGContext) => void

export interface APIResponse {
    KeyGeneration: KeyGeneration;
    Encryption:    Transform;
    Decryption:    Transform;
}

export interface Transform {
    IP:       string;
    FK_1:     Fk;
    SW:       string;
    FK_2:     Fk;
    Combined: string;
    IP_1:     string;
}

export interface Fk {
    EP:    string;
    XOR_1: string;
    Sbox:  string;
    P4:    string;
    XOR_2: string;
}

export interface KeyGeneration {
    P10:   string;
    LS1_L: string;
    LS1_R: string;
    P8_1:  string;
    LS2_L: string;
    LS2_R: string;
    P8_2:  string;
}

