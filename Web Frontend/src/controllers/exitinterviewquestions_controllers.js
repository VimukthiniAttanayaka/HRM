
import { getLabelText } from 'src/MultipleLanguageSheets'
import React, { useState, useEffect, useRef } from 'react'

let templatetype = 'translation_exitinterviewquestions'
let templatetype_base = 'translation'

export const columns = [
  {
    key: 'id',
    // label: '',
    label: getLabelText('ID', templatetype),
    // filter: false,
    // sorter: false,
    _style: { width: '20%' },
  },
  {
    key: 'Description',
    label: getLabelText('Description', templatetype),
    _style: { width: '20%' },
  },

  {
    key: 'EntryType',
    label: getLabelText('EntryType', templatetype),
    _style: { width: '20%' }
  },
  {
    key: 'status',
    label: getLabelText('Status', templatetype),
    _style: { width: '20%' }
  },
  {
    key: 'show_details',
    label: '',
    _style: { width: '1%' },
    filter: false,
    sorter: false,
  },
  {
    key: 'view',
    label: '',
    _style: { width: '1%' },
    filter: false,
    sorter: false,
  },
  {
    key: 'delete',
    label: '',
    _style: { width: '1%' },
    filter: false,
    sorter: false,
  },
];

export const headers = [["id", "Description", "EntryType", "status"]];

export const GetDataList = (data) => {
  return data.map(elt => [elt.id, elt.Description, elt.EntryType, elt.status]);
}