import { CostumeGarment } from './costume-garment';

export class Costume {
  costumeId: number;
  description: string;
  name: string;
  photo: string;
  costumeGarments: CostumeGarment[];
}
