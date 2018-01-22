import { Garment } from './garment';

export class GarmentType {
  garmentTypeId: number;
  name: string;
  description: string;
  photo: string;
  garments: Garment[];
}
