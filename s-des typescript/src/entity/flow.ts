export class Transform {
  IP?: string;
  FK_1?: FK;
  SW?: string;
  FK_2?: FK;
  Combined?: string;
  IP_1?: string;
}

export class FK {
  EP?: string;
  XOR_1?: string;
  Sbox?: string;
  P4?: string;
  XOR_2?: string;
}

export class KeyGeneration {
  P10?: string;
  LS1_L?: string;
  LS1_R?: string;
  P8_1?: string;
  LS2_L?: string;
  LS2_R?: string;
  P8_2?: string;
}

export class Root {
  KeyGeneration?: KeyGeneration;
  Encryption?: Transform;
  Decryption?: Transform;
}
