import { GarmentType } from './garment-type';

export class Costume {
  costumeId: number;
  description: string;
  name: string;
  photo: string;
  garmentTypes: GarmentType[];
}
