/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NetworkDeck : INetworkSerializable, IEquatable<RemoteFileSourceInformation>{

    public List<GameObject> cardDeck;

    public int SourceId;
    public FixedString32Bytes FilePath;
    public FixedString32Bytes SourceName;

    public RemoteFileSourceInformation(int sourceId, FixedString32Bytes filePath, FixedString32Bytes sourceName, )
    {
        SourceId = sourceId;
        FilePath = filePath;
        SourceName = sourceName;
    }

    // INetworkSerializable
    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref SourceId);
        serializer.SerializeValue(ref FilePath);
        serializer.SerializeValue(ref SourceName);
    }
    // ~INetworkSerializable


    // IEquatable
    public bool Equals(RemoteFileSourceInformation other)
    {
        return SourceId == other.SourceId && FilePath.Equals(other.FilePath) && SourceName.Equals(other.SourceName);
    }

    public override bool Equals(object obj)
    {
        return obj is RemoteFileSourceInformation other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SourceId, FilePath, SourceName);
    }

    // ~IEquatable
}*/