export async function getJson(url: string) {
  const resp = await fetch(url);
  if (resp.status === 204) return null;
  return resp.json();
}

export async function getText(url: string) {
  const resp = await fetch(url);
  return resp.text();
}
