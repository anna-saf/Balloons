namespace Balloons.Features.Records
{
    using Balloons.Features.Utilities;
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Спавнер списка рекордов
    /// </summary>
    public class RecordViewSpawner : MonoBehaviour
    {
        [SerializeField]
        protected RecordFacade recordRowPrefab = default;
        [SerializeField]
        protected Transform spawnParent = default;

        protected GenericEventList<RecordNameData> recordsData = default;

        protected List<RecordFacade> recordFacades = new List<RecordFacade>();  
        protected List<RecordNameData> recordNameDatas = new List<RecordNameData>();

        [Inject]
        protected virtual void Construct(GenericEventList<RecordNameData> recordsData) =>
            this.recordsData = recordsData;

        protected virtual void OnEnable()
        {
            OnAllRecordsCleared();
            SpawnRecordsData();
            recordsData.onAddedToList += OnRecordAdded;
            recordsData.onRemovedFromList += OnRecordRemoved;
            recordsData.onClearedList += OnAllRecordsCleared;
        }

        protected virtual void OnDisable()
        {
            recordsData.onAddedToList -= OnRecordAdded;
            recordsData.onRemovedFromList -= OnRecordRemoved;
            recordsData.onClearedList -= OnAllRecordsCleared;
        }

        private void OnRecordAdded(RecordNameData recordNameData)
        {
            recordNameDatas = new List<RecordNameData>(recordsData.GenericList);
            SortRecords(recordNameDatas);
            RecordFacade recordFacade = SpawnRecord(recordNameData);
            recordFacade.transform.SetSiblingIndex(recordNameDatas.IndexOf(recordNameData));
        }

        private void OnRecordRemoved(RecordNameData recordNameData)
        {
            int recordIdx = recordNameDatas.IndexOf(recordNameData);
            if(recordIdx >= 0)
            {
                Destroy(recordFacades[recordIdx]);
                recordFacades.RemoveAt(recordIdx);
            }
        }

        private void OnAllRecordsCleared()
        {
            foreach(RecordFacade recordFacade in recordFacades)
            {
                Destroy(recordFacade.gameObject);
            }
            recordFacades.Clear();
        }

        protected virtual void SpawnRecordsData()
        {
            List<RecordNameData> recordNameDatas = new List<RecordNameData>(recordsData.GenericList);

            if (recordNameDatas != null && recordNameDatas.Count > 0) 
            {
                SortRecords(recordNameDatas);

                foreach(RecordNameData recordNameData in recordNameDatas)
                {
                    SpawnRecord(recordNameData);
                }
            }
        }

        protected virtual void SortRecords(List<RecordNameData> recordNameDatas) =>
            recordNameDatas.Sort((x, y) => y.Score.CompareTo(x.Score));

        protected virtual RecordFacade SpawnRecord(RecordNameData recordNameData)
        {
            RecordFacade recordFacade = Instantiate(recordRowPrefab, spawnParent);
            if (recordFacade != null)
            {
                recordFacade.NameText.text = recordNameData.Name;
                recordFacade.ScoreText.text = recordNameData.Score.ToString();
            }
            recordFacades.Add(recordFacade);

            return recordFacade;
        }

    }
}
