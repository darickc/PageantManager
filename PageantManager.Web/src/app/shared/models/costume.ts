import { GarmentType } from './garment-type';

export class Costume {
  costumeId: number;
  pageantId: number;
  description: string;
  garmentTypes: GarmentType[];
}
