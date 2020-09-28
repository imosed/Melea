export interface EssentialOil {
  id: number;
  name: string;
}

export interface Blend {
  id: number;
  name: string;
  volumes: Array<Volume>;
}

export interface Volume {
  id: number;
  drops: number;
  oilId: number;
  oil: EssentialOil;
  blendId: number;
}
