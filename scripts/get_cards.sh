#!/bin/bash
# Fetches card data for the Forgetful Fish card list from the Scryfall API and
# writes the pretty-printed JSON to dandan_card_list.json.
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
OUT="$SCRIPT_DIR/../src/dandan/Resources/dandan_card_list.json"
mkdir -p "$(dirname "$OUT")"

CARDS='[
  {"name":"Dandan"},{"name":"Accumulated Knowledge"},{"name":"Brainstorm"},
  {"name":"Crystal Spray"},{"name":"Dance of the Skywise"},{"name":"Memory Lapse"},
  {"name":"Metamorphose"},{"name":"Mind Bend"},{"name":"Mystical Tutor"},
  {"name":"Predict"},{"name":"Ray of Command"},{"name":"Supplant Form"},
  {"name":"Unsubstantiate"},{"name":"Vision Charm"},{"name":"Diminishing Returns"},
  {"name":"Mystic Retrieval"},{"name":"Halimar Depths"},{"name":"Izzet Boilerworks"},
  {"name":"Lonely Sandbar"},{"name":"Mystic Sanctuary"},{"name":"Remote Isle"},
  {"name":"Svyelunite Temple"},{"name":"Temple of Epiphany"},{"name":"Island"}
]'

curl -s -X POST https://api.scryfall.com/cards/collection \
  -H "Content-Type: application/json" \
  -d "{\"identifiers\":${CARDS}}" \
| jq '{ data: [.data[] | {
    id,
    name,
    mana_cost,
    cmc,
    type_line,
    oracle_text,
    power,
    toughness,
    colors,
    color_identity,
    flavor_text
  }] }' > "$OUT"

echo "Wrote $(pwd)/$OUT"
