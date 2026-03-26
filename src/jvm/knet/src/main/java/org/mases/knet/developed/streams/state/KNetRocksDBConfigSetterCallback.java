package org.mases.knet.developed.streams.state;

import org.rocksdb.Options;

import java.util.Map;

public final class KNetRocksDBConfigSetterCallback implements org.mases.jcobridge.IJCListener {
    final org.mases.jcobridge.JCListener _internalListener;

    public KNetRocksDBConfigSetterCallback(String key) throws org.mases.jcobridge.JCNativeException {
        super();
        _internalListener = new org.mases.jcobridge.JCListener(key);
    }

    public synchronized void release() {
        _internalListener.release();
    }

    public synchronized void raiseEvent(String eventName) {
        _internalListener.raiseEvent(eventName);
    }

    public synchronized void raiseEvent(String eventName, Object e) {
        _internalListener.raiseEvent(eventName, e);
    }

    public synchronized void raiseEvent(String eventName, Object e, Object... objects) {
        _internalListener.raiseEvent(eventName, e, objects);
    }

    public Object getEventData() {
        return _internalListener.getEventData();
    }

    public boolean hasExtraData() {
        return _internalListener.hasExtraData();
    }

    public int extraDataLength() {
        return _internalListener.extraDataLength();
    }

    public Object[] extraData() {
        return _internalListener.extraData();
    }

    public Object getReturnData() {
        return _internalListener.getReturnData();
    }

    public void setReturnData(Object retData) {
        _internalListener.setReturnData(retData);
    }

    //@Override
    public void onSetConfig(KNetRocksDBConfigSetter setter, String s, Options options, Map<String, Object> map) {
        org.mases.jnet.developed.JNetEventResult eventDataExchange = new org.mases.jnet.developed.JNetEventResult();
        raiseEvent("onSetConfig", eventDataExchange, setter, s, options, map);
        if (!eventDataExchange.getHasOverride())
            throw new UnsupportedOperationException("The method shall be implemented in .NET side since does not have a default implementation within the JVM");
    }

    public void onClose(KNetRocksDBConfigSetter setter, String s, Options options) {
        org.mases.jnet.developed.JNetEventResult eventDataExchange = new org.mases.jnet.developed.JNetEventResult();
        raiseEvent("onClose", eventDataExchange, setter, s, options);
        if (!eventDataExchange.getHasOverride())
            throw new UnsupportedOperationException("The method shall be implemented in .NET side since does not have a default implementation within the JVM");
    }
}
