import { GarmentType } from './garment-type';

export class CostumeGarment {
  costumeGarmentId: number;
  costumeId: number;
  garmentTypeId: number;
  garmentType: GarmentType;

  public constructor(init?: Partial<CostumeGarment>) {
    Object.assign(this, init);
  }
}
