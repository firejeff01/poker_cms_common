namespace Poker.CMS.Common.Helpers
{
    using System;

    public class SnowflakeIdGenerator
    {
        private const long Twepoch = 1707801600000L; // 起始時間（2024-02-13 00:00:00 UTC）
        private const int MachineIdBits = 5;
        private const int DatacenterIdBits = 5;
        private const int SequenceBits = 12;

        private const long MaxMachineId = (1L << MachineIdBits) - 1;
        private const long MaxDatacenterId = (1L << DatacenterIdBits) - 1;
        private const long MaxSequence = (1L << SequenceBits) - 1;

        private long _lastTimestamp = -1L;
        private long _sequence = 0L;
        private readonly long _machineId;
        private readonly long _datacenterId;
        private readonly object _lock = new object();

        public SnowflakeIdGenerator(long machineId, long datacenterId)
        {
            if (machineId > MaxMachineId || machineId < 0)
                throw new ArgumentException($"Machine ID must be between 0 and {MaxMachineId}");
            if (datacenterId > MaxDatacenterId || datacenterId < 0)
                throw new ArgumentException($"Datacenter ID must be between 0 and {MaxDatacenterId}");

            _machineId = machineId;
            _datacenterId = datacenterId;
        }

        public long NextId()
        {
            lock (_lock)
            {
                long timestamp = GetCurrentTimestamp();
                if (timestamp < _lastTimestamp)
                    throw new Exception("Clock moved backwards. Refusing to generate ID.");

                if (timestamp == _lastTimestamp)
                {
                    _sequence = (_sequence + 1) & MaxSequence;
                    if (_sequence == 0)
                    {
                        timestamp = WaitNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    _sequence = 0;
                }

                _lastTimestamp = timestamp;

                return ((timestamp - Twepoch) << (MachineIdBits + DatacenterIdBits + SequenceBits)) |
                       (_datacenterId << (MachineIdBits + SequenceBits)) |
                       (_machineId << SequenceBits) |
                       _sequence;
            }
        }

        private long GetCurrentTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        private long WaitNextMillis(long lastTimestamp)
        {
            long timestamp = GetCurrentTimestamp();
            while (timestamp <= lastTimestamp)
            {
                timestamp = GetCurrentTimestamp();
            }
            return timestamp;
        }
    }
}