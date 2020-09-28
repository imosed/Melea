import { EssentialOil } from '@/types';
import { getJson } from '@/lib/req';

export async function getOils(): Promise<Array<EssentialOil>> {
  return getJson('/api/oils/list');
}

export async function getSomething() {
  console.log(1 + 2);
}
